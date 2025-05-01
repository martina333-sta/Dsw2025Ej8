namespace Dsw2025Ej8.Domain
{
    public class CuentaCorriente : CuentaBancaria
    {
        public CuentaCorriente(string numero, decimal saldo, decimal comision, decimal limite, string[] titulares) : base(numero, saldo, titulares)
        {
            Comision = comision;
            LimiteDeDescubierto = limite;
        }

        public override void Depositar(decimal monto)
        {
            Saldo += monto - Comision;
        }

        public override void Retirar(decimal monto)
        {
            if(Saldo - monto >= -LimiteDeDescubierto)
            {
                Saldo -= monto;
                if(Saldo < 0)
                {
                    Estado = Estado.Suspendida;
                }
            }
        }

        public override void AplicarInteres()
        {
            if(Saldo < 0)
            {
                decimal interesPorDescubierto = Saldo * TasaDeInteres;
                Saldo += interesPorDescubierto;
            }
        }

    }
}
