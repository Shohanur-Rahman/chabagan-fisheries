import { GridColDef } from "@mui/x-data-grid";
import { IconBreadcrumbs } from "../../components/common/IconBreadcrumbs";
import breadCrumb from './../../data/Breadcrumbs';
import { Grid } from "@mui/material";
import LoadDataGrid from "../../components/common/LoadDataGrid";
import { useEffect, useState } from "react";
import { useGetSupplerTransectionsQuery } from "../../redux/features/setup/supplierApi";
import { ProjectTitle } from "../../data/Config";

export default function TransectionSummary() {

    const [rows, setRows] = useState([]);
    const { data, isSuccess } = useGetSupplerTransectionsQuery(null);

    const columns: GridColDef[] = [
        { field: 'id', headerName: 'ID', filterable: true, headerClassName: "primary-header", flex: 1 },
        {
            field: 'supplier',
            headerName: 'Supplier',
            headerClassName: "primary-header",
            flex: 3
        },
        {
            field: 'purchaseDues',
            headerName: 'Pur.Due',
            headerClassName: "primary-header",
            flex: 2
        },
        {
            field: 'purchaseReturnDues',
            headerName: 'Pur.Ret.Due',
            headerClassName: "primary-header",
            flex: 2
        },
        {
            field: 'salesDues',
            headerName: 'Sale.Due',
            headerClassName: "primary-header",
            flex: 2
        },
        {
            field: 'salesReturnDues',
            headerName: 'Sale.Ret.Due',
            headerClassName: "primary-header",
            flex: 2
        },
        {
            field: 'balance', headerName: 'Balance',
            headerClassName: "primary-header",
            flex: 2,
            renderCell: (params) => {
                if (params.row.balance >= 0) {
                    return (<strong className="text-info">{params.row.balance}</strong>);
                } else {
                    return (<strong className="text-danger">{params.row.balance}</strong>);
                }
            }
        }
    ];

    useEffect(() => {
        document.title = `Transection Summaries | ${ProjectTitle}`;
    }, []);

    useEffect(() => {
        if (isSuccess && data) {
            setRows(data?.result);
        }
    }, [data, isSuccess]);

    return (
        <>
            <IconBreadcrumbs props={breadCrumb.transectionBreadCrumb} />

            <Grid item xs={12} sm={12} md={12} mt={2}>
                <LoadDataGrid title="Transection Summaries" rows={rows} columns={columns} />
            </Grid>
        </>
    )
}