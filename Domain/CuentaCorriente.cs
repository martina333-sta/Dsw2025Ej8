namespace Dsw2025Ej8.Domain
{
    public class CuentaCorriente : CuentaBancaria
    {
        public CuentaCorriente(string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares)
        {
            
        }

        public override void Depositar(decimal monto)
        {
            VerificarMontoEstado(monto);
            Saldo += monto - Comision;
        }

        public override void Retirar(decimal monto)
        {
            VerificarMontoEstado(monto);
            if(Saldo - monto < -LimiteDeDescubierto)
            {
                    Estado = Estado.Suspendida;
                    throw new SaldoInsuficiente("No se puede superar el limite de descubierto.");
                }

            Saldo -= monto;

            if(Saldo < 0)
            {
                Estado = Estado.Suspendida;
            }
        }

        public override void AplicarInteres()
        {
            if(Saldo < 0 && TasaDeInteres > 0)
            {
                decimal interesPorDescubierto = Saldo * TasaDeInteres;
                Saldo += interesPorDescubierto;
            }
        }

    }
}
