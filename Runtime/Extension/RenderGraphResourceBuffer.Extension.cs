namespace UnityEngine.Rendering.RenderGraphModule
{
    public partial struct BufferDesc
    {
        
        /// <summary>
        /// BufferDesc constructor.
        /// </summary>
        /// <param name="count">Number of elements in the buffer.</param>
        /// <param name="stride">Size of one element in the buffer.</param>
        /// <param name="target">Type of the buffer.</param>
        public BufferDesc(int count, int stride, string name, GraphicsBuffer.Target target = GraphicsBuffer.Target.Structured)
            : this()
        {
            this.count = count;
            this.stride = stride;
            this.target = target;
            this.name = name;
            this.usageFlags = GraphicsBuffer.UsageFlags.None;
        }

    }
}