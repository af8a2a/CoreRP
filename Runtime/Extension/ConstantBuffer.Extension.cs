namespace UnityEngine.Rendering
{
    partial class ConstantBuffer
    {
        /// <summary>
        /// Update the GPU data of the constant buffer and bind it globally via a command buffer.
        /// </summary>
        /// <typeparam name="CBType">The type of structure representing the constant buffer data.</typeparam>
        /// <param name="cmd">Command Buffer used to execute the graphic commands.</param>
        /// <param name="data">Input data of the constant buffer.</param>
        /// <param name="shaderId">Shader porperty id to bind the constant buffer to.</param>
        public static void PushGlobal<CBType>(ComputeCommandBuffer cmd, in CBType data, int shaderId) where CBType : struct
        {
            var cb = ConstantBufferSingleton<CBType>.instance;

            cb.UpdateData(cmd, data);
            cb.SetGlobal(cmd, shaderId);
        }


        /// <summary>
        /// Update the GPU data of the constant buffer and bind it to a compute shader via a command buffer.
        /// </summary>
        /// <typeparam name="CBType">The type of structure representing the constant buffer data.</typeparam>
        /// <param name="cmd">Command Buffer used to execute the graphic commands.</param>
        /// <param name="data">Input data of the constant buffer.</param>
        /// <param name="cs">Compute shader to which the constant buffer should be bound.</param>
        /// <param name="shaderId">Shader porperty id to bind the constant buffer to.</param>
        public static void Push<CBType>(ComputeCommandBuffer cmd, in CBType data, ComputeShader cs, int shaderId) where CBType : struct
        {
            var cb = ConstantBufferSingleton<CBType>.instance;

            cb.UpdateData(cmd, data);
            cb.Set(cmd, cs, shaderId);
        }
    }


    public partial class ConstantBuffer<CBType> : ConstantBufferBase where CBType : struct
    {
        public static void PushGlobal<CBType>(ComputeCommandBuffer cmd, in CBType data, int shaderId) where CBType : struct
        {
            var cb = ConstantBufferSingleton<CBType>.instance;

            cb.UpdateData(cmd, data);
            cb.SetGlobal(cmd, shaderId);
        }

        public static void Push<CBType>(ComputeCommandBuffer cmd, in CBType data, ComputeShader cs, int shaderId) where CBType : struct
        {
            var cb = ConstantBufferSingleton<CBType>.instance;

            cb.UpdateData(cmd, data);
            cb.Set(cmd, cs, shaderId);
        }

        public void SetGlobal(ComputeCommandBuffer cmd, int shaderId)
        {
            m_GlobalBindings.Add(shaderId);
            cmd.SetGlobalConstantBuffer(m_GPUConstantBuffer, shaderId, 0, m_GPUConstantBuffer.stride);
        }

        public void Set(ComputeCommandBuffer cmd, ComputeShader cs, int shaderId)
        {
            cmd.SetComputeConstantBufferParam(cs, shaderId, m_GPUConstantBuffer, 0, m_GPUConstantBuffer.stride);
        }


        public void UpdateData(ComputeCommandBuffer cmd, in CBType data)
        {
            m_Data[0] = data;
#if UNITY_2021_1_OR_NEWER
            cmd.SetBufferData(m_GPUConstantBuffer, m_Data);
#else
            cmd.SetComputeBufferData(m_GPUConstantBuffer, m_Data);
#endif
        }
    }
}