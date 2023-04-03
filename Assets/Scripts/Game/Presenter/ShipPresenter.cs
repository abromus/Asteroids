namespace Asteroids.Game
{
    public class ShipPresenter
    {
        private ShipModel _model;
        private ShipView _view;

        public ShipPresenter(ShipModel model, ShipView view)
        {
            _model = model;
            _view = view;
        }
    }
}
