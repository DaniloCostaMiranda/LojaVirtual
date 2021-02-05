using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LVirt.Models;
using LVirt.Repositories.Contracts;

namespace LVirt.Libraries.Validacao
{
    public class EmailUnicoColaboradorAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string Email = (value as string).Trim();

            IColaboradorRepository _colaboradorRepository = (IColaboradorRepository) validationContext.GetService(typeof(IColaboradorRepository));

            List<Colaborador> colaboradores = _colaboradorRepository.ObterColaboradorPorEmail(Email);

            Colaborador objColaborador = (Colaborador) validationContext.ObjectInstance;

           if(colaboradores.Count > 1)
            {
                return new ValidationResult("Email já existe");
            }
           if(colaboradores.Count == 1 && objColaborador.Id != colaboradores[0].Id)
            {
                return new ValidationResult("Email já existente");
            }

            return ValidationResult.Success;

            //TODO colaboradores > 1 = Rejietar

            // TOdo colaborador ==1 && ObjColadoror.ID != colaboradores[0].Id;


            //return ValidationResult.Sucess;

            // return base.IsValid(value, validationContext);
        }
        // pegar valor do campo email, obter o repository do colaborador, fazer verificaçao
       
    }
}
