﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Final_ProgWebIII.Core.Interface
{
    public interface ITokenService
    {
        string GenerateTokenEventos(string nome, string permissao);
    }
}
