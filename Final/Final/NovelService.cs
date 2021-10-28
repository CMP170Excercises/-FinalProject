using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    public interface NovelService
    {
        IList<Novel> SearchNovel(string keyword, string NoVol);
        Novel LoadById(long id);
        void UpdateNovel(Novel novel);
        void DeleteById(int id);
    }
}
