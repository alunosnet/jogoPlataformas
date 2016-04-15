using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        int opMenu; //posição selecionada no menu
        Texture2D opJogar;
        Texture2D opSair;
        bool disparou = false;
        Jogo jogo;

        public EstruturaJogo(Game game)
        {
            this.game = game;
        }
        public void Initialize()
        {
            estado = 0;

            opMenu = 1;

            jogo = new Jogo(game);
            jogo.Initialize();

            //login
            frm_login f = new frm_login();
            DialogResult resposta=f.ShowDialog();
            if (resposta == DialogResult.OK)
            {
                MessageBox.Show("ok");
                //testar login com servidor
                //guardar inventario
            }
            else
            {
                MessageBox.Show("cancel");
            }
        }
        public void LoadContent()
        {
            opJogar = game.Content.Load<Texture2D>("jogar");
            opSair = game.Content.Load<Texture2D>("sair");
            jogo.LoadContent();
        }
        public void Update(GameTime gameTime)
        {
            //atualizar jogo
            if (estado == 0) atualizarMenu();
            //atualizar menu
            if (estado == 1) if(jogo.Update(gameTime)) estado=0;
        }
        public void atualizarMenu()
        {
            
            //teclas
            teclado = Keyboard.GetState();

            gamepad = GamePad.GetState(PlayerIndex.One);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back ==Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                game.Exit();

            if (GamePad.GetState(PlayerIndex.One).Buttons.A == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                return;


            if (teclado[Microsoft.Xna.Framework.Input.Keys.Down] == KeyState.Down || teclado[Microsoft.Xna.Framework.Input.Keys.Up] == KeyState.Down || teclado[Microsoft.Xna.Framework.Input.Keys.Enter] == KeyState.Down)
            {
                if (disparou == true) return;
                disparou = true;
            }
            else
                disparou = false;

            if (teclado[Microsoft.Xna.Framework.Input.Keys.Up] == KeyState.Down)
            {
                disparou = true;
                opMenu--;
            }
            if (teclado[Microsoft.Xna.Framework.Input.Keys.Down] == KeyState.Down)
            {
                opMenu++;
                disparou = true;
            }
            if (opMenu < 1) opMenu = 2;
            if (opMenu > 2) opMenu = 1;

            if (teclado[Microsoft.Xna.Framework.Input.Keys.Enter] == KeyState.Down)
            {
                if (opMenu == 1) estado = 1;
                if (opMenu == 2) game.Exit();
            }

            return;

        }
        public void Draw(GameTime gameTime,GraphicsDevice dispositivo, SpriteBatch spriteBatch)
        {
            dispositivo.Clear(Color.CornflowerBlue);
            //iniciar desenhar
            spriteBatch.Begin();
            
            //desenhar menu
            if (estado == 0)
                desenhaMenu(gameTime, spriteBatch);
            //desenhar jogo
            if (estado == 1)
                jogo.Draw(gameTime,dispositivo, spriteBatch);
            
            //terminar desenhar
            spriteBatch.End();
        }
        public void desenhaMenu(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Rectangle rtemp;
            Color cor;

            
            if (opMenu==1)
                cor = Color.White;
            else
                cor = Color.Brown;
            rtemp = new Rectangle(0, 0, opJogar.Width, opJogar.Height);
            spriteBatch.Draw(opJogar, rtemp, cor);

            if (opMenu==2)
                cor = Color.White;
            else
                cor = Color.Brown;

            rtemp = new Rectangle(0, 200, opSair.Width, opSair.Height);
            spriteBatch.Draw(opSair, rtemp, cor);

            
        }

    }
}
