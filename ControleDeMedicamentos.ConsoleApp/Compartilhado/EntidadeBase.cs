namespace ControleDeMedicamentos.ConsoleApp.Compartilhado;

public abstract class EntidadeBase<T>
{
    public Guid Id { get; set; }

    public abstract void AtualizarRegistro(T registroEditado);
    public abstract string Validar();
}
