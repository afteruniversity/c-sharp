namespace exercicio04CelularGrupo20.Views;

public partial class Principal : ContentPage
{
	public Principal()
	{
		InitializeComponent();
	}

    private void exibirDadosClicked(object sender, EventArgs e)
    {
        if ((string.IsNullOrWhiteSpace(celFabricante.Text)))
        {
            DisplayAlert("Erro", "Verifique se a caixa de texto Marca do Celular está vazia !!!!", "OK");
            celFabricante.Focus();
        }
        else if (string.IsNullOrWhiteSpace(celModelo.Text))
        {
            DisplayAlert("Erro", "Verifique se a caixa de texto Modelo do Celular está vazia !!!!", "OK");
            celModelo.Focus();
        }
        else
        {
            DisplayAlert("Dados do Celular", "Marca do Celular: " + celFabricante.Text + "\n Modelo do Celular: " + celModelo.Text, "OK");
        }

    }

    private void limparClicked(object sender, EventArgs e)
    {
        celFabricante.Text = "";
        celModelo.Text = "";
        celFabricante.Focus();

    }

    private async void sairClicked(object sender, EventArgs e)
    {
        var resultado = await DisplayAlert("Alerta", "Deseja realmente sair?", "Sim", "Não");
        if (resultado) System.Diagnostics.Process.GetCurrentProcess().Kill();

    }
}