export interface IApiResponse {
    status: number;
    data: {
        hasErrors: boolean;
        succeeded: boolean;
        errors: string[];
    };
}
