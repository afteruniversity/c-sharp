namespace exercicio02Grupo01.Views;

public partial class Principal : ContentPage
{
	public Principal()
	{
		InitializeComponent();
	}

    private void Cleslley(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Cleslley());
    }

    private void Amanda(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Amanda());
    }

    private void Cesar(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Cesar());
    }

    private void Felipe(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Felipe());
    }

    private void Matheus(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Matheus());
    }

    private void Victor(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Victor());
    }

    private void Gabriel(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Gabriel());
    }
}