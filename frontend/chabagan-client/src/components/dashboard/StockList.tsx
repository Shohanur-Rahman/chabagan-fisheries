import { DataGrid, GridColDef, GridToolbar } from "@mui/x-data-grid";
import { useEffect, useState } from "react";
import { useGetProductStocksQuery } from "../../redux/features/setup/productApi";
import { Card, CardContent } from "@mui/material";

const StockList: React.FC<{}> = ({ }) => {
    const [rows, setRows] = useState([]);
    const { data, isSuccess } = useGetProductStocksQuery(null);
    const columns: GridColDef[] = [
        { field: 'id', headerName: 'ID', flex: 3, headerClassName: "primary-header", filterable: true },
        {
            field: 'name',
            headerName: 'Name',
            flex: 6,
            headerClassName: "primary-header"
        },
        {
            field: 'stock',
            headerName: 'Stock',
            flex: 3,
            headerClassName: "primary-header"
        }
    ];


    useEffect(() => {
        if (isSuccess && data) {
            setRows(data?.result);
        }
    }, [data, isSuccess]);

    return (
        <Card sx={{ minWidth: 275, minHeight: 370 }} className="card w-100">
            <CardContent>
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
                    rowHeight={30}
                    columnHeaderHeight={30}
                    disableColumnMenu
                    initialState={{
                        pagination: { 
                            paginationModel: { 
                                pageSize: 7 
                            } 
                        }
                    }}
                />
            </CardContent>
        </Card>
    )
}

export default StockList;