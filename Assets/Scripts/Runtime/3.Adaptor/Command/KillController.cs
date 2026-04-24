using Application;

namespace Adaptor
{
    public class KillController
    {
        public KillController(IKillUseCase killUseCase)
        {
            _killUseCase = killUseCase;
        }
        public void Kill(int id)
        {
            _killUseCase.Kill(id);
        }
        private readonly IKillUseCase _killUseCase;
    }
}
