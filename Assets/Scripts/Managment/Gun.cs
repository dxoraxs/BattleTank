public class Gun
{
    private GunVisual GunVisual;
    private GunShot GunShot;

    public Gun(GunVisual gunVisual, GunShot shot)
    {
        GunVisual = gunVisual;
        GunShot = shot;
    }

    public void Show() => GunVisual.Show();
    public void Hide() => GunVisual.Hide();
    public void Shot() => GunShot.Shot();
}