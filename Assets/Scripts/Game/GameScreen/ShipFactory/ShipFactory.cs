namespace Asteroids.Game.Factory
{
    public sealed class ShipFactory : IShipFactory
    {
        private readonly IShipViewFactory _shipViewFactory;

        public ShipFactory(IShipViewFactory shipViewFactory)
        {
            _shipViewFactory = shipViewFactory;
        }

        public ShipPresenter Create()
        {
            var shipModel = new ShipModel();
            var shipView = _shipViewFactory.Create();
            var shipPresenter = new ShipPresenter(shipModel, shipView);

            return shipPresenter;
        }
    }
}
