using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jogoPlataformas
{
    //Classe que implementa:
    // - Menu do jogo
    // - ciclo do Jogo
    class EstruturaJogo
    {
        KeyboardState teclado;
        GamePadState gamepad;
        Game game;
        int estado; //0-Menu; 1-Jogo; 2-Pausa
        public EstruturaJogo(Game game)
        {
            this.game = game;
        }
        public void Initialize()
        {
            estado = 0;
        }
        public void LoadContent()
        {

        }
        public void Update(GameTime gameTime)
        {

        }
    }
}
