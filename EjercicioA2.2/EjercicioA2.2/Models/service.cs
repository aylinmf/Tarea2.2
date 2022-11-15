using EjercicioA2._2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioA2_2.Models
{
    public class service
{
        public async Task<bool> saveSignatures(signature signature)
        {
            var result = await App.DBase.insertUpdateSignature(signature);

            return (result > 0);

        }


        public async Task<List<signature>> GetSignatures()
        {
            return await App.DBase.getListSignature();
        }


    }
}

