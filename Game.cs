using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;

namespace LetraU
{
    class Game : GameWindow
    {
        public Game(int width, int height) : base(width, height, GraphicsMode.Default, "Diseño Letra U - 3D")
        {
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(0.0f, 0.5f, 0.0f, 1.0f);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);
            float aspectRatio = (float)Width / Height;
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.DegreesToRadians(45.0f), aspectRatio, 0.1f, 100.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);
            // Configura la cámara
            Matrix4 modelview = Matrix4.LookAt(
                new Vector3(1.5f, 2f, 3.5f), // Posición de la cámara
                new Vector3(0.0f, 0.1f, 0.0f), // Punto de mira
                Vector3.UnitY); // Vector arriba
            GL.LoadMatrix(ref modelview);

            GL.PushMatrix();

            GL.Begin(PrimitiveType.LineLoop);
                // Parte frontal
                GL.Color4(0.0f, 0.0f, 0.0f, 0.0f);
                GL.Vertex3(-0.4f, 0.6f, 0.15f);
                GL.Vertex3(-0.2f, 0.6f, 0.15f);
                GL.Vertex3(-0.2f, -0.4f, 0.15f);
                GL.Vertex3(-0.4f, -0.4f, 0.15f);            
            GL.End();

            GL.Begin(PrimitiveType.LineLoop);            
                //GL.Color4(0.5f, 0.5f, 0.0f, 0.0f);
                GL.Vertex3(-0.4f, 0.6f, 0.15f);
                GL.Vertex3(-0.4f, 0.6f, -0.15f);
                GL.Vertex3(-0.2f, 0.6f, -0.15f);
                GL.Vertex3(-0.2f, 0.6f, 0.15f);
            GL.End();

            GL.Begin(PrimitiveType.LineLoop);
                // Parte superior
                GL.Vertex3(-0.4f, -0.4f, -0.15f);
                GL.Vertex3(-0.2f, -0.4f, -0.15f);
                GL.Vertex3(-0.2f, -0.4f, 0.15f);
                GL.Vertex3(-0.4f, -0.4, 0.15f);            
            GL.End();

            GL.Begin(PrimitiveType.LineLoop);
            // Parte Atras
                GL.Color4(0.0f, 0.0f, 0.0f, 0.0f);
                GL.Vertex3(-0.4f, 0.6f, -0.15f);
                GL.Vertex3(-0.2f, 0.6f, -0.15f);
                GL.Vertex3(-0.2f, -0.4f, -0.15f);
                GL.Vertex3(-0.4f, -0.4f, -0.15f);
            GL.End();

            GL.Begin(PrimitiveType.LineLoop);
            // Parte Lateral Izq
                GL.Color4(0.0f, 0.0f, 0.0f, 0.0f);
                GL.Vertex3(-0.4f, 0.6f, 0.15f);
            GL.Vertex3(-0.4f, 0.6f, -0.15f);
            GL.Vertex3(-0.4f, -0.4f, -0.15f);
                GL.Vertex3(-0.4f, -0.4f, 0.15f);                
            GL.End();
            
            GL.Begin(PrimitiveType.LineLoop);
            // Parte Lateral Der
                GL.Color4(0.0f, 0.0f, 0.0f, 0.0f);
                GL.Vertex3(-0.2f, 0.6f, 0.15f);
                GL.Vertex3(-0.2f, 0.6f, -0.15f);
                GL.Vertex3(-0.2f, -0.4f, -0.15f);
                GL.Vertex3(-0.2f, -0.4f, 0.15f);                
            GL.End();

            // Segundo rectángulo (parte base horizontal de la U)
            GL.Begin(PrimitiveType.LineLoop);
            // Parte frontal
            GL.Color4(0.0f, 0.0f, 0.0f, 0.0f);
            GL.Vertex3(-0.2f, -0.2f, 0.15f);
            GL.Vertex3(0.2f, -0.2f, 0.15f);  
            GL.Vertex3(0.2f, -0.4f, 0.15f); 
            GL.Vertex3(-0.2f, -0.4f, 0.15f); 
            GL.End();
            GL.Begin(PrimitiveType.LineLoop);
            // Parte superior 
            GL.Vertex3(-0.2f, -0.2f, 0.15f);
            GL.Vertex3(0.2f, -0.2f, 0.15f);
            GL.Vertex3(0.2f, -0.2f, -0.15f);
            GL.Vertex3(-0.2f, -0.2f, -0.15f);
            GL.End();
            GL.Begin(PrimitiveType.LineLoop);
            // Parte inferior
            GL.Vertex3(-0.2f, -0.4f, 0.15f);
            GL.Vertex3(0.2f, -0.4f, 0.15f);
            GL.Vertex3(0.2f, -0.4f, -0.15f);
            GL.Vertex3(-0.2f, -0.4f, -0.15f);
            GL.End();
            GL.Begin(PrimitiveType.LineLoop);
            // Parte trasera
            GL.Color4(0.0f, 0.0f, 0.0f, 0.0f);
            GL.Vertex3(-0.2f, -0.2f, -0.15f);
            GL.Vertex3(0.2f, -0.2f, -0.15f);
            GL.Vertex3(0.2f, -0.4f, -0.15f);
            GL.Vertex3(-0.2f, -0.4f, -0.15f);
            GL.End();
            GL.Begin(PrimitiveType.LineLoop);
            // Parte lateral izq (compartida con el lateral vertical izquierdo)
            GL.Color4(0.0f, 0.0f, 0.0f, 0.0f);
            GL.Vertex3(-0.2f, -0.2f, 0.15f);
            GL.Vertex3(-0.2f, -0.2f, -0.15f);
            GL.Vertex3(-0.2f, -0.4f, -0.15f);
            GL.Vertex3(-0.2f, -0.4f, 0.15f);
            GL.End();
            GL.Begin(PrimitiveType.LineLoop);
            // Parte lateral der (compartida con el lateral vertical derecho)
            GL.Color4(0.0f, 0.0f, 0.0f, 0.0f);
            GL.Vertex3(0.2f, -0.2f, 0.15f);
            GL.Vertex3(0.2f, -0.2f, -0.15f);
            GL.Vertex3(0.2f, -0.4f, -0.15f);
            GL.Vertex3(0.2f, -0.4f, 0.15f);
            GL.End();


            // Tercer rectángulo (lado derecho vertical de la U)
            GL.Begin(PrimitiveType.LineLoop);
            // Parte frontal
            GL.Color4(0.0f, 0.0f, 0.0f, 0.0f);
            GL.Vertex3(0.2f, 0.6f, 0.15f);
            GL.Vertex3(0.4f, 0.6f, 0.15f);
            GL.Vertex3(0.4f, -0.4f, 0.15f);
            GL.Vertex3(0.2f, -0.4f, 0.15f);
            GL.End();
            GL.Begin(PrimitiveType.LineLoop);
            // Parte superior
            GL.Vertex3(0.2f, 0.6f, 0.15f);
            GL.Vertex3(0.4f, 0.6f, 0.15f);
            GL.Vertex3(0.4f, 0.6f, -0.15f);
            GL.Vertex3(0.2f, 0.6f, -0.15f);
            GL.End();
            GL.Begin(PrimitiveType.LineLoop);
            // Parte inferior 
            GL.Vertex3(0.2f, -0.4f, 0.15f);
            GL.Vertex3(0.4f, -0.4f, 0.15f);
            GL.Vertex3(0.4f, -0.4f, -0.15f);
            GL.Vertex3(0.2f, -0.4f, -0.15f);
            GL.End();
            GL.Begin(PrimitiveType.LineLoop);
            // Parte trasera
            GL.Color4(0.0f, 0.0f, 0.0f, 0.0f);
            GL.Vertex3(0.2f, 0.6f, -0.15f);
            GL.Vertex3(0.4f, 0.6f, -0.15f);
            GL.Vertex3(0.4f, -0.4f, -0.15f);
            GL.Vertex3(0.2f, -0.4f, -0.15f);
            GL.End();
            GL.Begin(PrimitiveType.LineLoop);
            // Parte lateral izq (compartida con la base horizontal)
            GL.Color4(0.0f, 0.0f, 0.0f, 0.0f);
            GL.Vertex3(0.2f, 0.6f, 0.15f);
            GL.Vertex3(0.2f, 0.6f, -0.15f);
            GL.Vertex3(0.2f, -0.4f, -0.15f);
            GL.Vertex3(0.2f, -0.4f, 0.15f);
            GL.End();
            GL.Begin(PrimitiveType.LineLoop);
            // Parte lateral der
            GL.Color4(0.0f, 0.0f, 0.0f, 0.0f);
            GL.Vertex3(0.4f, 0.6f, 0.15f);
            GL.Vertex3(0.4f, 0.6f, -0.15f);
            GL.Vertex3(0.4f, -0.4f, -0.15f);
            GL.Vertex3(0.4f, -0.4f, 0.15f);
            GL.End();

            GL.PopMatrix();

            SwapBuffers();
        }
    }
}
