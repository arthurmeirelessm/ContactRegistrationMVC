using ContactRegistrationMVC.Filters;
using ContactRegistrationMVC.Models;
using ContactRegistrationMVC.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContactRegistrationMVC.Controllers
{
    [PageRestrictOnlyAdmin]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //METODOS VIEWS, RETORNA SEMPRE REDIRECIONAMENTO DE TELA
        //Quando for realzar o CRUD, sempre indicar o tipo de metodo que aquela tela precisará
        //como no metodo "Index" abaixo, que busca o metdo seachAll que está dentro de _userRepository
        //Isso indicará que essa tela precisará foi uma busca de todos os contatos registrados no backEnd
        public IActionResult Index()
        {
            List<UserModel> seachAll = _userRepository.SeachAll();
            return View(seachAll);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult ConfirmDelete(int id)
        {
            UserModel user = _userRepository.ListById(id);
            return View(user);
        }

        //O metodo edit precisa equalizar o id vindo da aplicação passado no index, no botão de redirecionar pra edit com os ids ja cadastrados no banco
        //é por isso que ele retorna View passando o valor do Id encotrado pela variavel user.
        //Assim, a view Edit es´ta ciente que irá usar o id do UserModel
        public IActionResult Edit(int id)
        {
            UserModel user = _userRepository.ListById(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Create(UserModel user)
        {
            //Segue o seguinte pensamento dos comentários nesse metodo! 
            //Esse If é pra validar se a model passada está no padrão de validação como ter um campo obrigatorio ou qualquer tipo de regex
            //Essa validação é feita pelo ModelState e passada com o isValid
            //Caso a model esteja válida, ele fará o crud de criação de usuario e retornará para a tela "index"
            //caso não, será redirecionado para a mesma tela, que é a do seu View de create
            //Pensamento paralelo ao de chatbots, REDIRECIONAMENTO DE TELAS apartir de validações e não REDIRECIONAMENTO DE BLOCOS

            try
            {
                if (ModelState.IsValid)
                {
                    _userRepository.Add(user);
                    TempData["MessageSuccess"] = "User registration with success";
                    return RedirectToAction("Index");
                }

                return View(user);
            }
            catch (System.Exception error)
            {
                TempData["MessageFailed"] = $"User not registration. Error message {error.Message}";
                return RedirectToAction("Index");
            }
        }



        public IActionResult DeleteContact(int id)
        {
            try
            {
                var VerifyIfDelete = _userRepository.Delete(id);
                if (VerifyIfDelete && ModelState.IsValid)
                {
                    TempData["MessageSuccess"] = "User deleted with success";
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");

            }
            catch (System.Exception error)
            {
                TempData["MessageFailed"] = $"Failed to delete user. Error: {error.Message}";
                return RedirectToAction("Index");
            }
        }


        [HttpPost]

        public IActionResult EditUser(UserWithoutPasswordModel userWithoutPassword)
        {
            try
            {
                UserModel user = null;

                if (ModelState.IsValid)
                {
                    user = new UserModel()
                    {
                        Id = userWithoutPassword.Id,
                        Name = userWithoutPassword.Name,
                        Email = userWithoutPassword.Email,
                        Login = userWithoutPassword.Login,
                        UserType = userWithoutPassword.UserType
                    };

                    _userRepository.UpdateEdit(user);
                    TempData["MessageSuccess"] = "User update with success";
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            catch (System.Exception error)
            {
                TempData["MessageFailed"] = $"Failed to update user. Error: {error.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
