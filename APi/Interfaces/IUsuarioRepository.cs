using Domains;
<<<<<<< HEAD
using Senai.InLock.WebApi.ViewModel;
=======
>>>>>>> cbfcb0183feaad0320512b3ebcef5d27bddd47d9
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<UsuariosDomain> Listar();
<<<<<<< HEAD
        UsuariosDomain BuscarPorEmailSenha(LoginViewModel login);
=======

        void Cadastrar(UsuariosDomain novoUsuario);
>>>>>>> cbfcb0183feaad0320512b3ebcef5d27bddd47d9
    }
}
