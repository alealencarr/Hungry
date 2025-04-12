using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hungry.Domain.Enums
{

    public enum StatusPedido
    {
        Criado,
        EmPreparo,
        Pronto,
        Pago,
        Finalizado
    }

    public enum MetodoPagamento
    {
        NaoDefinido = 0,
        Dinheiro = 1,
        CartaoCredito = 2,
        CartaoDebito = 3,
        Pix = 4
    }

}
