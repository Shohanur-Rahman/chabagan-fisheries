import { ComponentType, ReactNode } from "react";

export interface IRouteConfig {
    path?: string,
    element?: ReactNode,
    child?: IRouteConfig[],
    sidebarProps?: {
        displayText: string,
        icon?: ComponentType;
    }
}