using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Models;
using TaskManagement.Services;
using CryptSharp;

namespace TaskManagement.Services
{
    public static class CrypterService
    {
        public static string HashPassword(string password)
        {
            return Crypter.MD5.Crypt(password);
        }

        public static bool ComparePassword(string password, string hash)
        {
            return Crypter.CheckPassword(password, hash);
        }

    }
}