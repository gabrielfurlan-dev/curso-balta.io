namespace Furlan.dev.ViewModels
{
    internal class ResultViewModel<T>
    {
        private object data;
        private string error;
        private object erros;

        public ResultViewModel(string error)
        {
            this.error = error;
        }

        public ResultViewModel(object data)
        {
            this.data = data;
        }

        public ResultViewModel(string error, object erros) : this(error)
        {
            this.erros = erros;
        }
    }
}