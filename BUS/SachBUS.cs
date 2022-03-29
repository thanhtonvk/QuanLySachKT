using QuanLySachKT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    internal class SachBUS
    {
        string baseUrl = "https://localhost:44335/";
        public IEnumerable<Sach> GetSaches()
        {
            List<Sach> saches = new List<Sach>();
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var response = client.GetAsync("api/sach/getall");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    saches = result.Content.ReadAsAsync<List<Sach>>().Result;
                }
            }
            return saches;
        }
        public Sach GetSachByID(int id)
        {
            Sach sach = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var response = client.GetAsync($"api/sach/getsachbyid/{id}");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    sach = result.Content.ReadAsAsync<Sach>().Result;
                }
            }
            return sach;
        }
        public IEnumerable<Sach> GetSachByName(string name)
        {
            List<Sach> saches = new List<Sach>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var response = client.GetAsync($"Thuvien/Sachs/{name}");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    saches = result.Content.ReadAsAsync<List<Sach>>().Result;
                }
            }
            return saches;
        }
        public IEnumerable<Sach> GetSachByLinhVu(string linhvuc)
        {
            List<Sach> saches = new List<Sach>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var response = client.GetAsync($"Thuvien_Sachs/public/{linhvuc}");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    saches = result.Content.ReadAsAsync<List<Sach>>().Result;
                }
            }
            return saches;
        }
        public int GetSoLuongByNXB(string XuatBan)
        {
            int rs = 0;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var response = client.GetAsync($"Sachs/{XuatBan}");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    rs = result.Content.ReadAsAsync<int>().Result;
                }
            }
            return rs;
        }
        public IEnumerable<Sach> GetSachAfter2020()
        {
            List<Sach> saches = new List<Sach>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var response = client.GetAsync("Sachs/getafter2020");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    saches = result.Content.ReadAsAsync<List<Sach>>().Result;
                }
            }
            return saches;
        }
        public IEnumerable<Sach> GetSachesSoLanTaiBan()
        {
            List<Sach> saches = new List<Sach>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var response = client.GetAsync("Sachs/sotaibans");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    saches = result.Content.ReadAsAsync<List<Sach>>().Result;
                }
            }
            return saches;
        }
        public int Add(Sach sach)
        {
            int rs = -1;
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var response = client.PostAsJsonAsync("api/Sachs/post", sach);
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    rs = result.Content.ReadAsAsync<int>().Result;
                }
            }
            return rs;
        }
        public int Update(Sach sach)
        {
            int rs = -1;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var response = client.PutAsJsonAsync("api/Sachs/put", sach);
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    rs = result.Content.ReadAsAsync<int>().Result;
                }
            }
            return rs;
        }
        public int Delete(int id)
        {
            int rs = -1;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var response = client.DeleteAsync($"api/Sachs/delete?id={id}");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    rs = result.Content.ReadAsAsync<int>().Result;
                }
            }
            return rs;
        }
    }
}
