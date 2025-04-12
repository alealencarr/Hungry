using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hungry.Domain.ValueObjects
{
    public class Cpf
    {
        public string Numero { get; }

        public Cpf(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("CPF não pode ser vazio");

            if (!Validar(numero))
                throw new ArgumentException("CPF inválido");

            Numero = numero;
        }

        private bool Validar(string cpf)
        {
            // Regra simplificada pra foco didático
            return cpf.Length == 11 && cpf.All(char.IsDigit);
        }

        public override string ToString() => Numero;
    }
}

 
