using ExpectedObjects;

namespace Teste
{
    /*
    Eu, como livraria, preciso cadastrar livros para que 
    sejam vendidos em minha loja.

    Critérios de aceite: 
    - Um novo livro deve ter obrigatóriamente título, autor,
    ano de publicação, número ISBN, e número de páginas.
    */
    public class LivroTeste
    {
        private string _titulo;
        private string _autor;
        private string _data_publi;
        private int _num_isbn;
        private int _num_pag;


        public LivroTeste()
        {
            this._titulo = "Ruff Ghanor";
            this._autor = "Leonel Caldela";
            this._data_publi = "16/08/2016";
            this._num_isbn = 1234;
            this._num_pag = 345;
        }

        [Fact]
        public void CriarObjeto()
        {
            //Arrange
            //Reorganizado

            //Act

            //Livro livro = new Livro(this._titulo, this._autor, this._data_publi, this._num_isbn, this._num_pag);

            //Assert
                //Assert.Equal(this._titulo, livro.Titulo);
               //Assert.Equal(this._autor, livro.Autor);
              //Assert.Equal(this._data_publi, livro.Data_publi);
             //Assert.Equal(this._num_isbn, livro.Num_isbn);
            //Assert.Equal(this._num_pag, livro.Num_pag);

            var obj = new
            {
                Titulo = this._titulo,
                Autor = this._autor,
                Data_publi = this._data_publi,
                Num_isbn = this._num_isbn,
                Num_pag = this._num_pag,
            };

            Livro livro = new Livro(
                obj.Titulo, obj.Autor, obj.Data_publi, obj.Num_isbn, obj.Num_pag);

            obj.ToExpectedObject().ShouldMatch(livro);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void LivroNomeInvalido(string tituloInvalido)
        {
            var mensagem = Assert.Throws<ArgumentException>(
                () =>
               new Livro(tituloInvalido, this._autor, this._data_publi, this._num_isbn, this._num_pag)
               ).Message;

            Assert.Equal("Titulo inválido", mensagem);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void PaginaInvalido(int PaginaInvalido)
        {
            var mensagem = Assert.Throws<ArgumentException>(
                () =>
               new Livro(this._titulo, this._autor, this._data_publi, this._num_isbn, PaginaInvalido)
               ).Message;
            Assert.Equal("Pagina inválido", mensagem);
        }
    }

    public class Livro
    {
        private string titulo;

        private string autor;

        private string data_publi;

        private int num_isbn;

        private int num_pag;

        public string Titulo { get => titulo; private set => titulo = value; }
        public string Autor { get => autor; private set => autor = value; }
        public string Data_publi { get => data_publi; private set => data_publi = value; }
        public int Num_isbn { get => num_isbn; private set => num_isbn = value; }
        public int Num_pag { get => num_pag; private set => num_pag = value; }

        public Livro(string titulo, string autor, string data_publi, int num_isbn, int num_pag)
        {
            if (string.IsNullOrEmpty(titulo)) //(titulo == "" || titulo = null);
            {
                throw new ArgumentException("Titulo inválido");
            }

            if (num_pag <= 0)
            {
                throw new ArgumentException("Pagina inválido");
            }

            Titulo = titulo;
            Autor = autor;
            Data_publi = data_publi;
            Num_isbn = num_isbn;
            Num_pag = num_pag;
        }

    }
}