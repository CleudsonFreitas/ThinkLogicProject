import { useNavigate } from "react-router-dom";
import { Event } from "./../types/event";
import { useMutation, useQuery, useQueryClient } from "react-query";
import Config from "../config";
import axios, { AxiosError, AxiosResponse } from "axios";
import Problem from "../types/problem";

const useFetchEvents = () => {
    return useQuery<Event[], AxiosError>("events", () =>
        axios.get(`${Config.baseApiUrl}/events`).then((resp) => resp.data)
    );
};

const useFetchEvent = (id: number) => {
    return useQuery<Event, AxiosError>(["events", id], () =>
      axios.get(`${Config.baseApiUrl}/event/${id}`).then((resp) => resp.data)
    );
  };

const useAddEvent = () => {
    const queryClient = useQueryClient();
    const nav = useNavigate();
    return useMutation<AxiosResponse, AxiosError<Problem>, Event>(
        (h) => axios.post(`${Config.baseApiUrl}/events`, h),
        {
            onSuccess: () => {
                queryClient.invalidateQueries("events");
                nav("/");
            },
        }
    );
};

const useUpdateEvent = () => {
    const queryClient = useQueryClient();
    const nav = useNavigate();
    return useMutation<AxiosResponse, AxiosError<Problem>, Event>(
      (h) => axios.put(`${Config.baseApiUrl}/events`, h),
      {
        onSuccess: (_, event) => {
          queryClient.invalidateQueries("events");
          nav(`/event/${event.id}`);
        },
      }
    );
  };


export {
    useFetchEvents,
    useFetchEvent,
    useAddEvent,
    useUpdateEvent
}