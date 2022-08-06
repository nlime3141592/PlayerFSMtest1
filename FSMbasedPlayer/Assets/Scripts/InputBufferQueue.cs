using System;
using System.Collections.Generic;
using UnityEngine;

public class InputBufferQueue
{
    public Queue<KeyCode>[] queues;
    public KeyCode[] m_availableKeySet;
    public int m_frame = 0;
    public int m_frameCount;
    public QueueMode mode = QueueMode.Immediate;

    public enum QueueMode
    {
        Immediate, Buffer
    }

    public InputBufferQueue(int frameCount, params KeyCode[] availableKeySet)
    {
        queues = new Queue<KeyCode>[frameCount + 1];
        m_availableKeySet = availableKeySet;
        m_frameCount = frameCount + 1;

        for(int i = 0; i < frameCount + 1; i++)
        {
            queues[i] = new Queue<KeyCode>();
        }
    }

    public void AddFrame()
    {
        m_frame = ++m_frame % m_frameCount;
        queues[m_frame].Clear();
    }

    public void EnqueueKeys()
    {
        foreach(KeyCode key in m_availableKeySet)
        {
            if(Input.GetKey(key) && !queues[m_frame].Contains(key))
            {
                queues[m_frame].Enqueue(key);
            }
        }
    }

    public IEnumerable<KeyCode> DequeueKeys()
    {
        for(int i = 0; i < m_frameCount; i++)
        {
            int idx = (m_frame - i + m_frameCount) % m_frameCount;

            while(queues[idx].Count > 0)
            {
                yield return queues[idx].Dequeue();
            }
        }
    }

    public void Flush()
    {
        for(int i = 0; i < m_frameCount; i++)
        {
            queues[i].Clear();
        }
    }
}