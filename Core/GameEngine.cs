using Core.Input;
using Core.Interfaces;
using Core.MapObjects;

namespace Core
{
    public class GameEngine : IGameEngine
    {
        const int DEFAULT_DELAY = 50;
        private readonly IPlayerCharacter _player;
        private readonly IDrawingService _drawingService;
        private readonly IInputActionMapService _inputActionMapService;
        private readonly IRenderArea _area;
        private int _delay = DEFAULT_DELAY;

        public GameEngine(IPlayerCharacter playerCharacter, IDrawingService drawingService, IRenderArea renderArea, IInputActionMapService inputActionMapService)
        {
            _player = playerCharacter;
            _drawingService = drawingService;
            _area = renderArea;
            _inputActionMapService = inputActionMapService;
            _inputActionMapService.Subscribe(GameInput.EndGame, Stop);
        }

        public bool IsRunning { get; private set; } = false;

        public Task StartAsync(Coordinate origin, int width, int height, int delay = DEFAULT_DELAY)
        {
            _delay = delay;

            _area.Initialize(origin, width, height);
            _player.SetPosition(new Coordinate(10, 10));
            _area.SetMapObject(_player);
            IsRunning = true;
            return Task.Factory.StartNew(Draw);
        }

        public void Stop()
        {
            IsRunning = false;
        }

        public void ProcessInput(GameInput input)
        {
            _inputActionMapService.Invoke(input);
        }

        private void Draw()
        {
            if (_area is null)
            {
                return;
            }

            var previousFrameObjectTable = new Dictionary<int, Coordinate>();

            while (IsRunning)
            {
                var objectsToDraw = new List<IMappable>();

                var movedObjects = _area
                    .MapObjects
                    .Where(o => !previousFrameObjectTable.ContainsKey(GetMappableHash(o)));

                objectsToDraw.AddRange(movedObjects);

                var objectsToClear = previousFrameObjectTable
                    .Keys
                    .Except(_area.MapObjects.Select(o => GetMappableHash(o)))
                    .Select(h => new EmptySpace(previousFrameObjectTable[h]));

                objectsToDraw.AddRange(objectsToClear);

                _drawingService.Draw(objectsToDraw);

                previousFrameObjectTable.Clear();
                foreach (var mapObject in _area.MapObjects)
                {
                    previousFrameObjectTable.Add(GetMappableHash(mapObject), mapObject.Coordinate);
                }

                Thread.Sleep(_delay);
            }
        }

        private static int GetMappableHash(IMappable mappable)
        {
            return HashCode.Combine(mappable.SymbolKey, mappable.Coordinate.X, mappable.Coordinate.Y);
        }
    }
}