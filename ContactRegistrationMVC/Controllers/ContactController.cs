using ContactRegistrationMVC.Models;
using ContactRegistrationMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContactRegistrationMVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;


        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        //METODOS VIEWS, RETORNA SEMPRE REDIRECIONAMENTO DE TELA
        //Quando for realzar o CRUD, sempre indicar o tipo de metodo que aquela tela precisará
        //como no metodo "Index" abaixo, que busca o metdo seachAll que está dentro de _contactRepository
        //Isso indicará que essa tela precisará foi uma busca de todos os contatos registrados no backEnd
        public IActionResult Index()
        {

            List<ContactModel> seachAll = _contactRepository.SeachAll();
            return View(seachAll);

        }


        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            ContactModel contact = _contactRepository.ListById(id);
            return View(contact);
        }

        public IActionResult ConfirmDelete(int id)
        {
            ContactModel contact = _contactRepository.ListById(id);
            return View(contact);
        }

        //Metodos que puxam os outros metodos que tratam o que precisam do _dataContext
        //No exemplo abaixo, o metodo Create chama o metodo Add que esta dentro de _contactRepository
        //O objetivo é separar bem os metodos de Views que estão a cima e as de Ação que estão aqui em baixo

        [HttpPost]
        public IActionResult Create(ContactModel contact)
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
                    _contactRepository.Add(contact);
                    TempData["MessageSuccess"] = "Contact registration with success";
                    return RedirectToAction("Index");
                }

                return View(contact);
            }
            catch (System.Exception error)
            {
                TempData["MessageFailed"] = $"Contact not registration. Error message {error.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.UpdateEdit(contact);
                    TempData["MessageSuccess"] = "Contact changed with success";
                    return RedirectToAction("Index");
                }
                return View(contact);
            }
            catch (System.Exception error)
            {
                TempData["MessageFailed"] = $"Contact not changed. Error message {error.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult DeleteContact(int id)
        {
            try
            {
                bool wipedOut = _contactRepository.Delete(id);
                if (wipedOut)
                {
                    TempData["MessageSuccess"] = "Contact deleted with success";
                    return RedirectToAction("Index");
                } else
                {
                    TempData["MessageFailed"] = "Contact not deleted.";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception error)
            {
                TempData["MessageFailed"] = $"Contact not deleted. Error message {error.Message}";
                return RedirectToAction("Index");
            }


        }
    }
}
