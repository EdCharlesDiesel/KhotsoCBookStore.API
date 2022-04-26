namespace StarPeaceAdminHubDomain.ProductInterface
{

    public class BookLike: IBookLikeService
    {
        public void Like()
        {
            likes++;
            PresentStatus();
        }

        private void PresentStatus()
        {
            //! Will add to the database
            if (likes == 1)
                Console.WriteLine($"There is {likes} like to package {Name}");
            if (likes > 1)
                Console.WriteLine($"There are {likes} likes to package {Name}");
            if (dislikes == 1)
                Console.WriteLine($"There is {dislikes} dislike to package {Name}");
            if (dislikes > 1)
                Console.WriteLine($"There are {dislikes} dislikes to package {Name}");
            if (loves == 1)
                Console.WriteLine($"There is {loves} love to package {Name}");
            if (dislikes > 1)
                Console.WriteLine($"There are {loves} loves to package {Name}");
        }

        internal void UndoLike()
        {
            likes--;
            PresentStatus();
        }

        public void Dislike()
        {
            dislikes++;
            PresentStatus();
        }
        public void UndoDislike()
        {
            dislikes--;
            PresentStatus();
        }

        public void Love()
        {
            loves++;
            PresentStatus();
        }
        public void UndoLove()
        {
            loves--;
            PresentStatus();
        }
    }
}