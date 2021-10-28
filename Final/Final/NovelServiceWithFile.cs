using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Final
{
    public class NovelServiceWithFile : NovelService
    {
        private IList<Novel> m_novel;
        public NovelServiceWithFile()
        {
            var data = File.ReadAllText("LightNovel1_data.json");
            m_novel = JsonSerializer.Deserialize<List<Novel>>(data);
        }
        public void DeleteById(int id)
        {
            var deletedNovel = LoadById(id);
            if(deletedNovel != null)
            {
                m_novel.Remove(deletedNovel);
            }
        }

        public Novel LoadById(long id)
        {
            return m_novel.FirstOrDefault(x => x.Id == id);
        }

        public IList<Novel> SearchNovel(string keyword, string NoVol)
        {
            var result = m_novel.Where(s => (s.Volume == NoVol || string.IsNullOrEmpty(NoVol)) && (s.Author == keyword || s.Genre == keyword || string.IsNullOrEmpty(keyword))).OrderBy(s => s.Id).ToList();
            return result;
        }

        public void UpdateNovel(Novel novel)
        {
            var update = LoadById(novel.Id);
            update.Name = novel.Name;
            update.Author = novel.Author;
            update.Genre = novel.Genre;
            update.Volume = novel.Volume;
            update.Price = novel.Price;
        }
        

    }
}
