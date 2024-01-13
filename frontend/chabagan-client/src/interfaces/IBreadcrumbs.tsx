import { ReactNode } from "react";

export interface IIconBreadcrumbs {
    text: string,
    path?: string,
    icon?: ReactNode,
    isLast?: boolean
}