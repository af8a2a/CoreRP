namespace UnityEngine.Rendering
{
    partial class ComputeCommandBuffer
    {
        public void DispatchRays(RayTracingShader rayTracingShader, string rayGenName, uint width, uint height, uint depth)
        {
            m_WrappedCommandBuffer.DispatchRays(rayTracingShader, rayGenName, width, height, depth, null);
        }

        public void DispatchRays(RayTracingShader rayTracingShader, string rayGenName, GraphicsBuffer argsBuffer, uint argsOffset)
        {
            m_WrappedCommandBuffer.DispatchRays(rayTracingShader, rayGenName, argsBuffer, argsOffset, null);
        }

    }
}