namespace Dsw2025Ej8.Domain
{
    public class CajaDeAhorro : CuentaBancaria
    {
        public CajaDeAhorro(string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares)
        {
            
        }
        public override void Depositar(decimal monto) { 
            VerificarMontoEstado(monto);
            Saldo += monto;
        }

        public override void Retirar(decimal monto)
        {
            if (Saldo < monto) { 
            Estado = Estado.Suspendida;
            throw new SaldoInsuficiente("Saldo insuficiente");
        }
            Saldo -= monto;

        }
        public override void AplicarInteres()
        {
            if (TasaDeInteres > 0)
            {
                Saldo += Saldo * TasaDeInteres;
            }
        }
        
    }
}

