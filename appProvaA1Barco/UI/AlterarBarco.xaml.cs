using appProvaA1Barco.DAL;
using appProvaA1Barco.DTO;

namespace appProvaA1Barco.UI;

public partial class AlterarBarco : ContentPage
{
	public AlterarBarco()
	{
		InitializeComponent();
	}

    private async void salvarProduto(object sender, EventArgs e)
    {
        try
        {
            /*
             * Obt�m qual foi o Produto anexado no BindingContext da p�gina no momento que
             * ela foi criada e enviada para navega��o.
             */
            Barco BarcosAnexado = BindingContext as Barco;
            //Verificando se os elementos Entry est�o vazios ou nulos
            if ((string.IsNullOrWhiteSpace(txtNome.Text)))
            {
                await DisplayAlert("Erro", "Verifique se a caixa de texto Descri��o do Barco est� vazia !!!!", "OK");
                txtNome.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtPeso.Text))
            {
                await DisplayAlert("Erro", "Verifique se a caixa de texto Quantidade do Barco est� vazia !!!!", "OK");
                txtPeso.Focus();
            }
            else
            {
                /*
                 * Preenchendo o DTO de acordo com os valores dos Entry. Note que recuperamos a proID
                 * do BindingContext, como feito acima.
                 */
                Barco navio = new Barco
                {
                    BarID = BarcosAnexado.BarID,
                    BarNome = txtNome.Text,
                    BarPeso = Convert.ToDouble(txtPeso.Text)
                };
                /*
                 * M�todo para atualizar o registro no arquivo db3. Note que o m�todo recebe um DTO
                 * preenchido e neste deve conter o proID para que seja feito o Where(Altera��o) no comando Update.
                 */
                await App.BD.Update(navio);

                await DisplayAlert("Barco Alterado com Sucesso !!!!", "", "OK");

                await Navigation.PushAsync(new ListaBarco());
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro na Altera��o do Barco !!!!", ex.Message, "OK");
        }
    }
}