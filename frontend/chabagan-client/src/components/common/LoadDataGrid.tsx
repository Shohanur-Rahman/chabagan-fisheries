import { Card, CardContent, CardHeader } from "@mui/material";
import { DataGrid, GridColDef, GridToolbar } from "@mui/x-data-grid";
import { FC } from "react";

const LoadDataGrid: FC<{
    title: string,
    columns: GridColDef[],
    rows: never[],
    pageSize?: number,
    width?: number,
    rowHeight?: number
}> = ({ title, columns, rows, pageSize, width, rowHeight }) => {
    return (
        <Card sx={{ minWidth: (width ? width : 275) }} className="card w-100">
            <CardHeader title={title} className="card-header" />
            <CardContent className="table-content">
                <DataGrid
                    {...rows}
                    disableColumnFilter
                    disableColumnSelector
                    disableDensitySelector
                    columns={columns}
                    rows={rows}
                    slots={{ toolbar: GridToolbar }}
                    slotProps={{
                        toolbar: {
                            showQuickFilter: true,
                        },
                    }}
                    rowHeight={(rowHeight ? rowHeight : 40)}
                    columnHeaderHeight={(rowHeight ? rowHeight : 40)}
                    disableColumnMenu
                    initialState={{
                        pagination: {
                            paginationModel: {
                                pageSize: (pageSize ? pageSize : 10)
                            }
                        }
                    }}
                />
            </CardContent>
        </Card>
    )
}

export default LoadDataGrid;