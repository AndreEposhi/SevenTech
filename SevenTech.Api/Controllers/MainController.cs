using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace SevenTech.Api.Controllers
{
    public abstract class MainController : Controller
    {
        private readonly ICollection<string> erros = new List<string>();

        protected void AdicionarErro(string erro) => erros.Add(erro);

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoEhValida()) return Ok(result);

            var modelStateDictionary = new ModelStateDictionary();

            foreach (var erro in erros)
                modelStateDictionary.AddModelError("Message", erro);

            return BadRequest(modelStateDictionary);
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);

            foreach (var erro in erros)
                AdicionarErro(erro.ErrorMessage);

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                AdicionarErro(error.ErrorMessage);

            return CustomResponse();
        }

        protected void LimparErros() => erros.Clear();

        protected bool OperacaoEhValida() => !erros.Any();
    }
}