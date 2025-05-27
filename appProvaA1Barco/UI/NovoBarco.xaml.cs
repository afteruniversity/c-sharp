using appProvaA1Barco.DTO;
namespace appProvaA1Barco.UI;

public partial class NovoBarco : ContentPage
{
    public NovoBarco()
    {
        InitializeComponent();
    }
    /*
* Trata o evento Clicked do ToolbarItem
*/
    private async void salvarProduto(object sender, EventArgs e)
    {
        try
        {
            //Verificando se os elementos Entry estão vazios ou nulos
            if ((string.IsNullOrWhiteSpace(txtNome.Text)))
            {
                await DisplayAlert("Erro", "Verifique se a caixa de texto Descrição do Barco está vazia!!!!", "OK");
                txtNome.Focus();
            }
            else if(string.IsNullOrWhiteSpace(txtPeso.Text))
            {
                await DisplayAlert("Erro", "Verifique se a caixa de texto Quantidade do Barco está vazia!!!!", "OK");
                txtPeso.Focus();
            }
            else
            {
                /*
                * Preenchendo o DTO Produto com os dados informados na interface gráfica.
                */
                Barco navio = new Barco
                {
                    BarNome = txtNome.Text,
                    BarPeso = Convert.ToDouble(txtPeso.Text)
                };
                /*
                * Chamando o método insert da classe crudSQLite para fazer a inserção do
                * novo registro no arquivo db3 com os dados do DTO preenchidos acima.
                * O await denota que o código deve esperar o insert para prosseguir.
                */
                await App.BD.Insert(navio);
                /*
                * Avisando o usuário que deu certo.
                */
                await DisplayAlert("Barco Cadastrado com Sucesso !!!!", "", "OK");
                /*
                * Navegando para a tela de listagem.
                */
                await Navigation.PopAsync();
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro no Cadastro do Barco !!!!", ex.Message, "OK");
        }
    }
}