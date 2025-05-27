using appProvaA1Barco.DTO;
using System.Collections.ObjectModel;

namespace appProvaA1Barco.UI;

public partial class ListaBarco : ContentPage
{
    ObservableCollection<Barco> listagemBarcos = new ObservableCollection<Barco>();
    public ListaBarco()
	{
		InitializeComponent();
        lstBarco.ItemsSource = listagemBarcos;
    }
    /*
    * M�todo executado quando a p�gina � exibida ao usu�rio.
    */
    protected async override void OnAppearing()
    {
        try
        {
            listagemBarcos.Clear();
            List<Barco> temp = await App.BD.GetAll();
            temp.ForEach(i => listagemBarcos.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro Desconhecido !!!!", ex.Message, "OK");
        }
    }
    /*
    * Trata o evento TextChanged da SearchBar recebendo os novos valores digitados.
    */
    private async void txtBuscar(object sender, TextChangedEventArgs e)
    {
        try
        {
            /*
             * Obtendo o valor que foi digitado no Search
             */
            string busca = e.NewTextValue;
            lstBarco.IsRefreshing = true;
            /*
            * Limpando a ObservableCollection antes de add os itens vindos da busca.
            */
            listagemBarcos.Clear();
            List<Barco> temp = await App.BD.Search(busca);
            temp.ForEach(i => listagemBarcos.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro Desconhecido !!!!", ex.Message, "OK");
        }
        finally
        {
            lstBarco.IsRefreshing = false;
        }
    }
    /*
    * Trata o evento Clicked do MenuItem da ViewCell.ContextActions perguntando ao usu�rio
    * se ele realmente deseja remover o produto do arquivo db3
    */
    private async void excluirProduto(object sender, EventArgs e)
    {
        try
        {
            /*
             * Reconhecendo qual foi a linha do ListView que disparou o evento de exclus�o.
             */
            MenuItem itemSelecionado = sender as MenuItem;
            /*
            * Obtendo qual foi o Produto que estava anexado no BindingContext
            */
            Barco barcoSelecionado = itemSelecionado.BindingContext as Barco;
            /*
            * Perguntando ao usu�rio se ele realmente deseja remover. Note o await para aguardar
            * a resposta do usu�rio antes de prosseguir com o c�digo.
            */
            bool confirmacao = await DisplayAlert("Tem Certeza que quer excluir o Barco?", $"Excluir {barcoSelecionado.BarNome}", "Sim", "N�o");
            if (confirmacao)
            {
                /*
                 * Removendo o registro do db3 via m�todo Delete da classe crufSQLite
                 */
                await App.BD.Delete(barcoSelecionado.BarID);
                /*
                 * Removendo o item da ObservableCollection tamb�m, que � automaticamente
                 * removida da vis�o do usu�rio na ListView.
                 */
                listagemBarcos.Remove(barcoSelecionado);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro Desconhecido !!!!", ex.Message, "OK");
        }
    }
    /*
    * Trata o evento ItemSelected da ListView navegando para a p�gina de detalhes.
    */
    private void lstBarcoItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            Barco navio = e.SelectedItem as Barco;
            Navigation.PushAsync(new AlterarBarco
            {
                BindingContext = navio,
            });
        }
        catch (Exception ex)
        {
            DisplayAlert("Erro Desconhecido !!!!", ex.Message, "OK");
        }
    }
    private async void irIncluirBarco(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new NovoBarco());

        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro no Cadastro do Barco !!!!", ex.Message, "OK");
        }
    }
    private async void refCarregando(object sender, EventArgs e)
    {
        try
        {
            listagemBarcos.Clear();
            List<Barco> temp = await App.BD.GetAll();
            temp.ForEach(i => listagemBarcos.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro Desconhecido !!!!", ex.Message, "OK");
        }
        finally
        {
            lstBarco.IsRefreshing = false;
        }
    }
}