using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMind_challenge.Models
{
    class Usuario
    {
        public String name { get; set; }
        public String email_address { get; set; }

        /* 
            o ideal seria um DateTime para guardar data de nascimento
            do usuário e depois fazer o cálculo para conseguir idade.
        */
        public int age { get; set; }
    }
}
