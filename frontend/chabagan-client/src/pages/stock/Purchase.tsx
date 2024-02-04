import { useFormik } from "formik";
import * as Yup from "yup";
import { Box, Button, Card, CardContent, CardHeader, Grid } from "@mui/material";
import DoneAllIcon from '@mui/icons-material/DoneAll';
import KeyboardDoubleArrowLeftIcon from '@mui/icons-material/KeyboardDoubleArrowLeft';
import { IconBreadcrumbs } from "../../components/common/IconBreadcrumbs";
import purchaseBreadCrumb from '../../data/Breadcrumbs';
import { useEffect, useState } from "react";
import { ProjectTitle } from "../../data/Config";
import PurchaseInfo from "../../components/stock/PurchaseInfo";
import PurchaseCalculation from "../../components/stock/PurchaseCalculation";
import PurchaseForm from "../../components/stock/PurchaseForm";
import { IPurchaseModel } from "../../interfaces/model/stock/IPurchaseModel";
import PurchaseItems from "../../components/stock/PurchaseItems";
import { useAddDemoPurchaseMutation } from "../../redux/features/stock/purchaseApi";
export default function Purchase() {

    const [initialValues, setInitialValues] = useState<IPurchaseModel>(
        {
            id: 0,
            billNo: '',
            billDate: new Date(),
            supplierId: 0,
            totalAmount: 0,
            discount: 0,
            grandTotal: 0,
            paidAmount: 0,
            dues: 0,
            items: [],
            selectedSupplier: { label: '', value: '' },
            typeId: 1
        }
    );

    const [addDemoPurchase, { isLoading, isError, isSuccess, data, error }] = useAddDemoPurchaseMutation();

    const validationSchema = Yup.object({
        billNo: Yup.string().required('Bill is required'),
        supplierId: Yup.number().min(1, 'Supplier is required'),
        billDate: Yup.date().required('Date is required'),
        totalAmount: Yup.number().min(1, 'Total is required')
    });

    const formik = useFormik({
        initialValues: initialValues,
        enableReinitialize: true,
        validationSchema: validationSchema,
        onSubmit: (values) => {
            console.log("Payload", values)
            addDemoPurchase(values);
        }
    });

    useEffect(() => {
        document.title = `Purchase | ${ProjectTitle}`;
    }, []);

    useEffect(() => {

    }, [isSuccess, isError, data, error]);

    return (
        <>
            <IconBreadcrumbs props={purchaseBreadCrumb.purchaseBreadCrumb} />
            <Box mt={3}>
                <Grid container spacing={2}>
                    <Box component="form" className="w-100 card-form" noValidate onSubmit={formik.handleSubmit}>
                        <Grid item xs={12} sm={12} md={12} lg={12}>
                            <Card sx={{ minWidth: 275 }} className="card w-100">
                                <CardHeader title="Purchase" className="card-header" />
                                <CardContent className="table-content">
                                    <PurchaseInfo info={initialValues} formik={formik} setState={setInitialValues} />
                                    <PurchaseForm info={initialValues} setState={setInitialValues} />
                                    <Grid container spacing={2} mt={0}>
                                        <Grid md={8} item xs={6}>
                                            <PurchaseItems info={initialValues} setState={setInitialValues} />
                                        </Grid>
                                        <PurchaseCalculation info={initialValues} formik={formik} setState={setInitialValues} />
                                    </Grid>
                                    <Grid item xs={12}>
                                        <hr />
                                    </Grid>
                                    <Grid item xs={12}>
                                        <Button variant="outlined"> <KeyboardDoubleArrowLeftIcon />Back</Button>
                                        <Button type="submit"
                                            variant="contained"
                                            color="success"
                                            className="pull-right"
                                            disabled={(isLoading)}
                                        >
                                            Save Changes &nbsp;<DoneAllIcon />
                                        </Button>
                                    </Grid>
                                </CardContent>
                            </Card>
                        </Grid>
                    </Box>
                </Grid>
            </Box >
        </>
    )
}