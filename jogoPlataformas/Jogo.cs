using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jogoPlataformas
{
    class Jogo
    {
        Game game;
        KeyboardState teclado;
        GamePadState gamepad;
        Player player;

        public Jogo(Game game)
        {
            this.game = game;
        }
        public void Initialize()
        {
            player = new Player(game);
            player.Initialize();
        }
        public void LoadContent()
        {
            player.LoadContent();
        }
        //devolve true para voltar ao menu
        public bool Update(GameTime gameTime)
        {
            teclado = Keyboard.GetState();

            gamepad = GamePad.GetState(PlayerIndex.One);
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || teclado[Keys.Escape] == KeyState.Down)
            {
                return true;
            }
            //atualizar jogador
            player.Update(teclado);

            return false;
        }
        public void Draw(GameTime gameTime, GraphicsDevice dispositivo, SpriteBatch spriteBatch)
        {
            //fundo
            //plataformas
            //player
            player.Draw(spriteBatch);
            //inimigos
            //balas
            //explosoes
        }
    }
}
