using AutoMind_challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMind_challenge.Manager
{
    class UsuarioManager
    {
        public List<Usuario> UsersList = new List<Usuario>();

        public List<Usuario> getUsers()
        {
            return UsersList;
        }

        public void AddUser(Usuario user)
        {
            UsersList.Add(user);
        }

    }
}
