using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Final
{
    public class NovelDetailViewModel : BaseViewModel, ICloseable
    {
        private int idD;
        private string nameD;
        private string volumeD;
        private string authorD;
        private string genreD;
        private int priceD;
        private readonly NovelService m_novelService;
        public int id
        {
            get => idD; set
            {
                idD = value;
                OnPropertyChanged(nameof(idD));
            }
        }
        public String name
        {
            get => nameD; set
            {
                nameD = value;
                OnPropertyChanged(nameof(nameD));
            }
        }
        public String volume
        {
            get => volumeD; set
            {
                volumeD = value;
                OnPropertyChanged(nameof(volumeD));
            }
        }
        public String genre
        {
            get => genreD; set
            {
                genreD = value;
                OnPropertyChanged(nameof(genreD));
            }
        }
        public String author
        {
            get => authorD; set
            {
                authorD = value;
                OnPropertyChanged(nameof(authorD));
            }
        }
        public int price
        {
            get => priceD; set
            {
                priceD = value;
                OnPropertyChanged(nameof(priceD));
            }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        Novel m_novel;
        public NovelDetailViewModel(NovelService novelService, int Id)
        {
            m_novelService = novelService;
            m_novel = m_novelService.LoadById(Id);
            id = m_novel.Id;
            name = m_novel.Name;
            volume = m_novel.Volume;
            genre = m_novel.Genre;
            author = m_novel.Author;
            price = m_novel.Price;
            SaveCommand = new ConditionalCommand(x => DoSave());
            CancelCommand = new ConditionalCommand(x => DoCancel());
        }
        public event EventHandler CloseRequest;
        private void DoCancel()
        {
            var handler = CloseRequest;
            if (handler != null) handler(this, EventArgs.Empty);
        }
        private void DoSave()
        {
            m_novel.Id = id;
            m_novel.Name = name;
            m_novel.Genre = genre;
            m_novel.Volume = volume;
            m_novel.Author = author;
            m_novel.Price = price;
            m_novelService.UpdateNovel(m_novel);
            DoCancel();
        }
    }
}
