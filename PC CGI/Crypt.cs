﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PC_CGI
{
    class Cryptor
    {
        Socket sock;
        public Cryptor(Socket Sock)
        {
            sock = Sock;
            //TODO Нужно Обменяься ключами с серером и поднять сеанс
        }

        public byte[] Encrypt(byte[] data)
        {
            return data;
        }

        public byte[] Decrypt(byte[] data)
        {
            return data;
        }

    }
}
