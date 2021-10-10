using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//https://fooobar.com/questions/63815/how-to-convert-a-structure-to-a-byte-array-in-c

namespace PC_CGI
{
    class DataDownload
    {
        Cryptor cryptor;
        DataDownload()
        {
            //Curve25519()
            cryptor = new Cryptor();
        }
    }


}
