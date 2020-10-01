using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pink.Environment
{
    public static partial class Simulation
    {
        static HeapQueue<Event> events = new HeapQueue<Event>();

        static public T Schedule<T>(float tick = 0) where T : Event, new()
        {
            var ev = new T();
            ev.tick = Time.time + tick;
            events.Push(ev);
            return ev;
        }

        static public void Clear()
        {
            events.Clear();
        }

        static public T GetModel<T>() where T : class, new()
        {
            return InstanceRegister<T>.instance;
        }

        static public void SetModel<T>(T instance) where T : class, new()
        {
            InstanceRegister<T>.instance = instance;
        }

        static public void DestroyModel<T>() where T : class, new()
        {
            InstanceRegister<T>.instance = null;
        }

        static public int Tick()
        {
            var time = Time.time;
            var runEvents = 0;
            while(events.Count > 0 && events.Peek().tick <= time) {
                var ev = events.Pop();
                var tick = ev.tick;
                ev.ExecuteEvent();

                runEvents++;
            }
            return runEvents;
        }
    }
}
