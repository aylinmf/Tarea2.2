using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioA2_2.Models
{
    public class bd
{
        readonly SQLiteAsyncConnection dbase;

        public bd(string dbpath)
        {
            dbase = new SQLiteAsyncConnection(dbpath);

            //Creacion de las tablas de la base de datos

            dbase.CreateTableAsync<signature>(); //Creando la tabla Signature

        }

       

        //Metodos CRUD - CREATE
        public Task<int> insertUpdateSignature(signature signature)
        {
            if (signature.Id != 0)
            {
                return dbase.UpdateAsync(signature);
            }
            else
            {
                return dbase.InsertAsync(signature);
            }
        }

        //Metodos CRUD - READ
        public Task<List<signature>> getListSignature()
        {
            return dbase.Table<signature>().ToListAsync();
        }

        public Task<signature> getSignature(int id)
        {
            return dbase.Table<signature>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        //Metodos CRUD - DELETE
        public Task<int> deleteSignature(signature signature)
        {
            return dbase.DeleteAsync(signature);
        }


    }
}

