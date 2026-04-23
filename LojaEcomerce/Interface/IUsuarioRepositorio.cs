using LojaEcomerce.Models;

namespace LojaEcomerce.Interface
{
    public interface IUsuarioRepositorio
    {
        // A interface nao contem codigo apenas na promessa do que deve 
        //ser feito (como um contrato)
        LoginViewModel Validar(string Email, string senha);
    }
}
