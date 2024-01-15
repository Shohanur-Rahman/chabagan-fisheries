import { useEffect } from "react";
import { IconBreadcrumbs } from "../../components/common/IconBreadcrumbs";
import userAddBreadCrumb from '../../data/Breadcrumbs';
import { ProjectTitle } from "../../data/Config";

export default function AddEditUser() {

    useEffect(() => {
        document.title = `Add User | ${ProjectTitle}`;
    }, []);

    return (
        <>
            <IconBreadcrumbs props={userAddBreadCrumb.userAddBreadCrumb} />
        </>
    )
}