namespace StarPeaceAdminHubDomain.ProductInterface
{

    public interface IBookLikeService
    {
        public void Like();
        

        private void PresentStatus();
        

        internal void UndoLike();
        

        public void Dislike();
       
        public void UndoDislike();
        

        public void Love();
        
        public void UndoLove();
        
    }
}