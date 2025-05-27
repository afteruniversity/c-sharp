using appProvaA1Barco.DTO;
using SQLite;

namespace appProvaA1Barco.DAL
{
    public class crudSQLite
    {
        readonly SQLiteAsyncConnection _conexao;
        public crudSQLite(string path)
        {
            _conexao = new SQLiteAsyncConnection(path);
            _conexao.CreateTableAsync<Barco>().Wait();
        }
        public Task<int> Insert(Barco navio)
        {
            return _conexao.InsertAsync(navio);
        }
        public Task<List<Barco>> Update(Barco navio)
        {
            string sql = "UPDATE Barco SET BarNome=?, BarPeso=? WHERE BarID =?";
            return _conexao.QueryAsync<Barco>(sql, navio.BarNome, navio.BarPeso, navio.BarID);
        }
        public Task<int> Delete(int idBar)
        {
            return _conexao.Table<Barco>().DeleteAsync(i => i.BarID == idBar);
        }
        public Task<List<Barco>> GetAll()
        {
            return _conexao.Table<Barco>().ToListAsync();
        }
        public Task<List<Barco>> Search(string buscaBar)
        {
            string sql = "SELECT * FROM Barco WHERE barNome LIKE '%" + buscaBar + "%'";
            return _conexao.QueryAsync<Barco>(sql);
        }
    }
}
